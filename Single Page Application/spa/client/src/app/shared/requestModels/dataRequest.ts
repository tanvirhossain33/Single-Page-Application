export class DataRequest {
    Id: string;
    Page: number;
    TotalPage: number;
    OrderBy: string;
    Keyword: string;
    IsAscending: string;
    ParentId: string;
    PerPageCount: number;

    protected getBaseQueryString(): string {
        if (this.Page == null) {
            this.Page = 1;
        }
        const queryString = `?keyword=${this.Keyword}&orderBy=${this.OrderBy}&page=${this.Page}`;
        return queryString;
    }
}
