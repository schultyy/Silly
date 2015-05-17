declare class Directory {
    static GetFiles(directory: ClrString): Array<ClrString>;
    static GetDirectories(directory: ClrString): Array<ClrString>;
    static GetParent(path: ClrString): DirectoryInfo;
}

interface DirectoryInfo {
    FullName: String;
}