///<reference path="Definitions/environment.d.ts" />

class Pwd {
    execute(env: Environment) {
        return env.CurrentWorkingDirectory;
    }
}

function call(env) {
    var ls = new Pwd();
    return ls.execute(env);
}