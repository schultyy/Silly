///<reference path="Definitions/environment.d.ts" />
///<reference path="Definitions/directory.d.ts" />

function cd(environment: Environment, newDirectory: String) {
    if (newDirectory === "..") {
        var parent = Directory.GetParent(environment.CurrentWorkingDirectory);
        if (parent === null) {
            return environment;
        }
        return new Environment(parent.FullName);
    }
    return environment;
}