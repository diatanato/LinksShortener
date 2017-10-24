import {NgModule}      from "@angular/core";
import {RouterModule}  from '@angular/router';
import {BrowserModule} from "@angular/platform-browser";
import {HttpModule}    from "@angular/http";
import {FormsModule}   from '@angular/forms';

import {AppComponent}        from "./components/app/app.component"
import {NavigationComponent} from "./components/navigation/navigation.component"
import {ShortenerComponent}  from "./components/shortener/shortener.component"
import {StatisticComponent}  from "./components/statistic/statistic.component"
import {RedirectComponent}   from "./components/redirect/redirect.component"

@NgModule({
    imports: [
        BrowserModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: "", redirectTo: "shortener", pathMatch: "full" },
            { path: "shortener", component: ShortenerComponent },
            { path: "statistic", component: StatisticComponent },
            { path: ':id', component: RedirectComponent },
            { path: "**", redirectTo: "shortener" }
        ])
    ],
    declarations: [
        AppComponent,
        NavigationComponent,
        ShortenerComponent,
        StatisticComponent,
        RedirectComponent
    ],
    bootstrap: [
        AppComponent
    ],
    providers: [
        { provide: "ORIGIN_URL", useValue: location.origin }
    ]
})
export class AppModule {
}