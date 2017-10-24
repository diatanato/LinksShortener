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
    templateUrl: "./statistic.component.html"
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