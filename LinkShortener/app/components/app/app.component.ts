import { Component } from "@angular/core";

@Component({
    selector: "app",
    template: 
`
<navigation></navigation>
<div class="container body-content">
    <router-outlet></router-outlet>
</div>
`
})
export class AppComponent {
}
