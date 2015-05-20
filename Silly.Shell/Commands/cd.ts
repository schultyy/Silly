///<reference path="../Definitions/environment.d.ts" />
///<reference path="../Definitions/directory.d.ts" />
///<reference path="../Definitions/clr_path.d.ts" />

function cd(environment: Environment, newDirectory: String) {
    if (newDirectory === "..") {
        var parent = Directory.GetParent(environment.CurrentWorkingDirectory);
        if (parent === null) {
            return environment;
        }
        return new Environment(parent.FullName);
    }

    if (Directory.Exists(newDirectory))
        return new Environment(newDirectory);
    var newPath = ClrPath.Combine(environment.CurrentWorkingDirectory, newDirectory)
    if (Directory.Exists(newPath))
        return new Environment(newPath);

    return environment;
}