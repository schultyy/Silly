declare class ClrArray<T> implements IEnumerable<T> {
}

declare class ClrList implements IEnumerable<any> {
    constructor(type: any);
    AddRange(collection: IEnumerable<any>);
    ToArray(): ClrArray<any>;
}

interface IEnumerable<T> {
}