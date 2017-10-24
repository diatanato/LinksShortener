import { Component } from "@angular/core";
import { Http, RequestOptions, URLSearchParams } from "@angular/http";

@Component({
    selector: "shortener",
    templateUrl: './shortener.component.html'
})
export class ShortenerComponent {
    constructor(private http: Http) { }

    public userLink = "";
    public shortLink = "";

    GetShortLink(userLink: string): void {

        let params: URLSearchParams = new URLSearchParams();
        params.set("link", userLink);

        this.http.post("/api/links/post", params).subscribe(
            result => { this.shortLink = window.location.host + "/" + result.json().shortLink;},
            error => { this.shortLink = null; }
        );
        this.userLink = null;
    }

}