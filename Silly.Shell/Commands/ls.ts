///<reference path="Definitions/directory.d.ts" />
///<reference path="Definitions/string.d.ts" />
///<reference path="Definitions/array.d.ts" />
///<reference path="Definitions/environment.d.ts" />

function ls(env: Environment) {
    var files = Directory.GetFiles(env.CurrentWorkingDirectory);
    var directories = Directory.GetDirectories(env.CurrentWorkingDirectory);
    var contents = new ClrList(ClrString);
    contents.AddRange(files);
    contents.AddRange(directories);
    return ClrString.Join("\r\n", contents);
}
