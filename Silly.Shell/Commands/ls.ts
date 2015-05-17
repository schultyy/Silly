class Ls {
    execute(env) {
    }
}

function call(env) {
    var ls = new Ls();
    return ls.execute(env);
}
