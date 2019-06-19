import { CommonModule } from "@angular/common";
import { BrowserModule } from "@angular/platform-browser";
import { RouterModule } from "@angular/router";
import { TooltipModule } from "ngx-bootstrap/tooltip/public_api";
import { NgxMaskModule } from "ngx-mask";
import { AppRoutingModule } from "../app-routing.module";
import { NgModule } from "@angular/core";
import { EscolaDashComponent } from "./escola-dash/escola-dash.component";

@NgModule({
  imports: [CommonModule, BrowserModule, RouterModule, NgxMaskModule.forRoot(), TooltipModule.forRoot(), AppRoutingModule],
  providers: [],
  declarations: [EscolaDashComponent]
  //exports: [RouterModule]
})
export class EscolaModule {}
