interface IEnvironment {
    CurrentWorkingDirectory: string;

}

declare class Environment implements IEnvironment {
    CurrentWorkingDirectory: string;
    constructor(path: String);
}