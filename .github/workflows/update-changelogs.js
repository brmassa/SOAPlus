import { readFileSync, writeFileSync, existsSync } from "fs";
import { join } from "path";

const version = process.argv[2];
const notes = process.argv[3];

if (!version) {
    console.error("No version provided");
    process.exit(1);
}

console.log(`Updating files for version ${version}`);

// List of package directories
const packageDirs = ["Builtin", "Core"];
const packagePrefix = "com.brunomassa.soaplus";

// Update package.json dependencies and version
function updatePackageJson(packagePath) {
    console.log(`Updating ${packagePath}`);
    const pkg = JSON.parse(readFileSync(packagePath, "utf8"));

    // Update version
    pkg.version = version;

    // Update dependencies
    if (pkg.dependencies) {
        Object.keys(pkg.dependencies).forEach((dep) => {
            if (dep.startsWith(packagePrefix)) {
                pkg.dependencies[dep] = version;
            }
        });
    }

    writeFileSync(packagePath, JSON.stringify(pkg, null, 2) + "\n");
    console.log(`Updated ${packagePath}`);
}

// Update changelog
function updateChangelog(changelogPath, notes) {
    console.log(`Updating ${changelogPath}`);
    const date = new Date().toISOString().split("T")[0];
    const newEntry = `# [${version}] - ${date}\n\n${notes}\n\n`;

    let existingContent = "";
    if (existsSync(changelogPath)) {
        existingContent = readFileSync(changelogPath, "utf8");
    }

    writeFileSync(changelogPath, newEntry + existingContent);
    console.log(`Updated ${changelogPath}`);
}

// Update all packages
packageDirs.forEach((dir) => {
    // Update package.json
    const packagePath = join(dir, "package.json");
    updatePackageJson(packagePath);

    // Update changelog
    const changelogPath = join(dir, "CHANGELOG.md");
    updateChangelog(changelogPath, notes);
});

// Update root changelog
updateChangelog("CHANGELOG.md", notes);
