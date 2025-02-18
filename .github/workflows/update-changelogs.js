const fs = require("fs");
const path = require("path");

const version = process.argv[2];
const notes = process.argv[3];

// List of package directories
const packageDirs = ["Builtin", "Core"];

packageDirs.forEach((dir) => {
    const changelogPath = path.join(dir, "CHANGELOG.md");
    const date = new Date().toISOString().split("T")[0];

    let changelog = "";
    if (fs.existsSync(changelogPath)) {
        changelog = fs.readFileSync(changelogPath, "utf8");
    }

    const newEntry = `# [${version}] - ${date}\n\n${notes}\n\n`;

    fs.writeFileSync(changelogPath, newEntry + changelog);
});

// Also update root changelog
const rootChangelogPath = "CHANGELOG.md";
let rootChangelog = "";
if (fs.existsSync(rootChangelogPath)) {
    rootChangelog = fs.readFileSync(rootChangelogPath, "utf8");
}
const rootEntry = `# [${version}] - ${date}\n\n${notes}\n\n`;
fs.writeFileSync(rootChangelogPath, rootEntry + rootChangelog);
