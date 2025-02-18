const fs = require("fs");
const path = require("path");

const version = process.argv[2];
const notes = process.argv[3];

// List of package directories
const packageDirs = ["Builtin", "Core"];
const packagePrefix = "com.brunomassa.soaplus";

// Debug function to print file contents
function debugPrintFile(filepath, label) {
    console.log(`\n=== ${label} ===`);
    console.log(`File: ${filepath}`);
    if (fs.existsSync(filepath)) {
        console.log(fs.readFileSync(filepath, "utf8"));
    } else {
        console.log("File does not exist yet");
    }
    console.log("=== End ===\n");
}

// Update package.json dependencies
function updatePackageDependencies(packagePath) {
    const pkg = JSON.parse(fs.readFileSync(packagePath, "utf8"));
    let updated = false;

    if (pkg.dependencies) {
        Object.keys(pkg.dependencies).forEach((dep) => {
            if (dep.startsWith(packagePrefix)) {
                pkg.dependencies[dep] = version;
                updated = true;
            }
        });
    }

    if (updated) {
        fs.writeFileSync(packagePath, JSON.stringify(pkg, null, 2) + "\n");
        console.log(`Updated dependencies in ${packagePath}`);
        debugPrintFile(packagePath, "Updated package.json");
    }
}

// Update changelogs
packageDirs.forEach((dir) => {
    // Update changelog
    const changelogPath = path.join(dir, "CHANGELOG.md");
    const date = new Date().toISOString().split("T")[0];

    let changelog = "";
    if (fs.existsSync(changelogPath)) {
        changelog = fs.readFileSync(changelogPath, "utf8");
    }

    const newEntry = `# [${version}] - ${date}\n\n${notes}\n\n`;

    fs.writeFileSync(changelogPath, newEntry + changelog);
    debugPrintFile(changelogPath, `${dir} Changelog`);

    // Update package.json
    const packagePath = path.join(dir, "package.json");
    updatePackageDependencies(packagePath);
});

// Update root changelog
const rootChangelogPath = "CHANGELOG.md";
let rootChangelog = "";
if (fs.existsSync(rootChangelogPath)) {
    rootChangelog = fs.readFileSync(rootChangelogPath, "utf8");
}
const rootEntry = `# [${version}] - ${date}\n\n${notes}\n\n`;
fs.writeFileSync(rootChangelogPath, rootEntry + rootChangelog);
debugPrintFile(rootChangelogPath, "Root Changelog");

// Print final summary
console.log("\n=== Update Summary ===");
console.log(`Version: ${version}`);
console.log("Release Notes:");
console.log(notes);
console.log("==================\n");
