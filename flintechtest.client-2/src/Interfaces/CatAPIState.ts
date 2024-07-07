export interface CatAPIState {
    catRoots?: any[];
    pagination: {
      page: number;
      limit: number;
      total: number;
    };
  }