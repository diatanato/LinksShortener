import { Component }                      from "@angular/core";
import { ActivatedRoute }                 from "@angular/router";
import { Http, URLSearchParams, Headers } from "@angular/http";

@Component({
    selector: "redirect",
    template: ``
})
export class RedirectComponent {

    public headers: Headers;

    constructor(private activateRoute: ActivatedRoute, private http: Http) {
        this.GetFullLink(activateRoute.snapshot.params["id"]);
    }

    GetFullLink(id: string): void {
        
        this.headers = new Headers();
        this.headers.append("Content-Type", "application/json");

        this.http.post("/api/links/getlink", JSON.stringify(id), { headers: this.headers }).subscribe(
            result => { window.location.href = result.json().fullLink; },
            error  => { window.location.href = "/shortener" }
        );
    }
}
