﻿///<reference path="directory.d.ts" />
///<reference path="string.d.ts" />
///<reference path="array.d.ts" />

class Ls {
    execute(env) {
        var files = Directory.GetFiles(env.CurrentWorkingDirectory);
        var directories = Directory.GetDirectories(env.CurrentWorkingDirectory);
        var contents = new ClrList(ClrString);
        contents.AddRange(files);
        contents.AddRange(directories);
        return ClrString.Join("\r\n", contents);
    }
}

function call(env) {
    var ls = new Ls();
    return ls.execute(env);
}
