import { Component } from "@angular/core";
import { Http, RequestOptions, URLSearchParams } from "@angular/http";

@Component({
    selector: "shortener",
    template:
`
<div class="row">
    <h1 for="url">Simplify your links</h1>
    <div class="input-group">
        <input [(ngModel)]="userLink" type="text" class="form-control" placeholder="Your original URL here"id="url">
        <span class="input-group-btn">
            <button type="submit" class="btn"  (click)="GetShortLink(userLink)">Shorten URL</button>
        </span>
    </div>
    <div>All {{hostname}} URLs and click analytics are public and can be accessed by anyone</div>
</div>
<div style="text-align: -webkit-center;">
    <h1>{{shortLink}}</h1>
</div>
`
})
export class ShortenerComponent {
    constructor(private http: Http) { }

    public userLink = "";
    public shortLink = "";
    public hostname = window.location.host;

    GetShortLink(userLink: string): void {

        let params: URLSearchParams = new URLSearchParams();
        params.set("link", userLink);

        this.http.post("/api/links/post", params).subscribe(
            result => { this.shortLink = this.hostname + "/" + result.json().shortLink;},
            error => { this.shortLink = null; }
        );
        this.userLink = null;
    }

}