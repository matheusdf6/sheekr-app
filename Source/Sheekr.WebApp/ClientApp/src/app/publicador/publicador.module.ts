import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule, Routes } from "@angular/router";
import { NovoPublicadorComponent } from "./novo-publicador/novo-publicador.component";
import { ReactiveFormsModule } from "@angular/forms";
import { PublicadoresClient } from "../sheekr-api";
import { NgxMaskModule } from "ngx-mask";
import {
  NgxUiLoaderModule,
  NgxUiLoaderConfig,
  NgxUiLoaderHttpModule
} from "ngx-ui-loader";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { ListPublicadoresComponent } from "../publicador/list-publicadores/list-publicadores.component";
import { AppRoutingModule } from "../app-routing.module";
import { HumanizeService } from "../humanize.service";
import { EditPublicadorComponent } from "./edit-publicador/edit-publicador.component";
import { BrowserModule } from "@angular/platform-browser";

const ngxUiLoaderConfig: NgxUiLoaderConfig = {
  bgsColor: "#720026",
  bgsOpacity: 0.5,
  bgsPosition: "bottom-right",
  bgsSize: 60,
  bgsType: "ball-spin-clockwise",
  blur: 7,
  fgsColor: "#ff0505",
  fgsPosition: "center-center",
  fgsSize: 80,
  fgsType: "three-bounce",
  gap: 24,
  logoPosition: "center-center",
  logoSize: 120,
  logoUrl: "",
  masterLoaderId: "master",
  overlayBorderRadius: "0",
  overlayColor: "rgba(40, 40, 40, 0.8)",
  pbColor: "#00ACC1",
  pbDirection: "ltr",
  pbThickness: 3,
  hasProgressBar: false,
  text: "",
  textColor: "#FFFFFF",
  textPosition: "center-center",
  threshold: 500
};

@NgModule({
  imports: [
    ReactiveFormsModule,
    CommonModule,
    BrowserModule,
    RouterModule,
    NgxMaskModule.forRoot(),
    NgxUiLoaderModule.forRoot(ngxUiLoaderConfig),
    NgxUiLoaderHttpModule.forRoot({}),
    AppRoutingModule
  ],
  providers: [PublicadoresClient, HumanizeService],
  declarations: [
    NovoPublicadorComponent,
    ListPublicadoresComponent,
    EditPublicadorComponent
  ]
  //exports: [RouterModule]
})
export class PublicadorModule {}
