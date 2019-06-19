import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { RouterModule } from "@angular/router";
import { CommonModule } from "@angular/common";

import { PublicadorModule } from "./publicador/publicador.module";

import { AppComponent } from "./app.component";
import { HomeComponent } from "./home/home.component";
import { ListAlunosComponent } from "./list-alunos/list-alunos.component";
import { NavbarComponent } from "./navbar/navbar.component";
import { SideMenuComponent } from "./side-menu/side-menu.component";
import { NovoPublicadorComponent } from "./publicador/novo-publicador/novo-publicador.component";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { AppRoutingModule } from ".//app-routing.module";
import { NgxUiLoaderRouterModule } from "ngx-ui-loader";
import { ToastrModule } from "ngx-toastr";
import { EventEmitterService } from "./event-emitter.service";
import { TooltipModule } from "ngx-bootstrap/tooltip";
import { EscolaModule } from "./escola/escola.module";

@NgModule({
  declarations: [AppComponent, HomeComponent, ListAlunosComponent, NavbarComponent, SideMenuComponent],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    CommonModule,
    BrowserAnimationsModule,
    HttpClientModule,
    NgxUiLoaderRouterModule.forRoot({}),
    TooltipModule.forRoot(),
    ToastrModule.forRoot({}),
    TooltipModule.forRoot(),
    FormsModule,
    PublicadorModule,
    EscolaModule,
    AppRoutingModule
  ],
  providers: [EventEmitterService],
  bootstrap: [AppComponent]
})
export class AppModule {}
