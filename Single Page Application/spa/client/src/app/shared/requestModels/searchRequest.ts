import { DataRequest } from './dataRequest';


export class SearchRequest extends DataRequest {
    constructor(keyword: string, orderBy: string, isAsc: string, parentId?: string, perPageCount: number = 10) {
        super();
        this.Keyword = keyword;
        this.OrderBy = orderBy;
        this.IsAscending = isAsc;
        this.ParentId = parentId;
        this.PerPageCount = perPageCount;
    }
}
