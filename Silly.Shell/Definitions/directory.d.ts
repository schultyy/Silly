declare class Directory {
    static GetFiles(directory: ClrString): Array<ClrString>;
    static GetDirectories(directory: ClrString): Array<ClrString>;
    static GetParent(path: ClrString): DirectoryInfo;
    static Exists(path: String|ClrString): Boolean;
}

interface DirectoryInfo {
    FullName: String;
}