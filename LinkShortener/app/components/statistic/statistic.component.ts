import {Component} from "@angular/core";
import {Http}      from "@angular/http";

export class LinkInformation {
    originalLink: string;
    creationDate: string;
    shortLink: string;
    count: string;

    constructor(originalLink: string, creationDate: string, shortLink: string,  count: string) {
        this.originalLink = originalLink;
        this.creationDate = creationDate;
        this.shortLink = shortLink;
        this.count = count;
    }
}

@Component({
    selector: "statistic",
    template: 
`
<div>
    <table class="table table-striped">
        <thead>
        <tr>
            <th>Original URL</th>
            <th>Creation date</th>
            <th>Short URL</th>
            <th>All clicks</th>
        </tr>
        </thead>
        <tbody>
        <tr *ngFor="let item of items">
            <td><a href="{{item.originalLink}}">{{item.originalLink}}</a></td>
            <td>{{item.creationDate}}</td>
            <td><a href="{{item.shortLink}}">{{hostname}}/{{item.shortLink}}</a></td>
            <td>{{item.count}}</td>
        </tr>
        </tbody>
    </table>
</div>
`
})
export class StatisticComponent {
    items: LinkInformation[] = [];
    hostname = window.location.host;
    
    constructor(private http: Http) {
        this.statistic();
    }

    statistic(): void {
        this.http.get("/api/links/statistic").subscribe(result => {
            var resultData = result.json();

            for (let i = 0; i < resultData.length; ++i) {

                this.items.push(new LinkInformation(resultData[i].originalLink, resultData[i].creationDate, resultData[i].shortLink, resultData[i].count));
            }
        });
    }
}