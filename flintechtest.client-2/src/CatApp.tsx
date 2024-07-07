import { Component } from 'react';
import { Grid, GridColumn } from '@progress/kendo-react-grid';
import { CatAPIState } from './Interfaces/CatAPIState';

class CatApp extends Component<{}, CatAPIState> {
    constructor(props: {}) {
        super(props);
        this.state = {
            catRoots: undefined,
            pagination: {
               page: 0,
               limit: 0,
               total: 0 
            }
        };
    }

    componentDidMount() {
        console.log('CatApp mounted');
        this.getCatAPI(this.state.pagination.page);      
    }

    pageChangeEvent = (event: any) => {
        let pageIndex = (event.page.skip / event.page.take);
        this.getCatAPI(pageIndex);
    }

    getCatAPI(pageIndex: number) {
        fetch('/api/Cat?page=' + pageIndex.toString())
        .then(response => response.json())
        .then(data => this.setState({ catRoots: data.catRoots, pagination: data.pagination }))
        .catch(error => console.error('Error fetching data:', error));
    }

    render() {
        return (
            <div>
                <h1>Cat API Data</h1>
                { this.state.catRoots ? 
                    (
                        <Grid
                        data={this.state.catRoots}
                        skip={this.state.pagination.page * this.state.pagination.limit}
                        take={this.state.pagination.limit}
                        total={this.state.pagination.total}
                        onPageChange={this.pageChangeEvent}
                        sortable pageable>
                            <GridColumn field="id" title="ID" />
                            <GridColumn
                                field="url"
                                title="Image"
                                cell={props => (
                                <td>
                                    <img src={props.dataItem.url} alt="Cat" style={{ width: '100px' }} />
                                </td>
                                )}
                            />
                            <GridColumn field="width" title="Width" />
                            <GridColumn field="height" title="Height" />
                        </Grid>
                    ) : (<p>Loading data...</p>)
                }
            </div>
        );
    }
}

export default CatApp;