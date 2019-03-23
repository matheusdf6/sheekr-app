import { Component, OnInit } from "@angular/core";
import {
  CriarPublicadorCommand,
  PublicadoresClient,
  SwaggerException
} from "src/app/sheekr-api";
import {
  FormGroup,
  FormControl,
  FormBuilder,
  Validators
} from "@angular/forms";
import { NgxUiLoaderService } from "ngx-ui-loader";
import { Router } from "@angular/router";
import { Location } from "@angular/common";

@Component({
  selector: "app-novo-publicador",
  templateUrl: "./novo-publicador.component.html",
  providers: [PublicadoresClient],
  styleUrls: ["./novo-publicador.component.css"]
})
export class NovoPublicadorComponent implements OnInit {
  command: CriarPublicadorCommand = new CriarPublicadorCommand();
  client: PublicadoresClient;
  ngxService: NgxUiLoaderService;
  publicador: FormGroup;
  result?: boolean;
  submited: boolean = false;
  loading: boolean = false;
  erros: string = null;

  constructor(
    client: PublicadoresClient,
    fb: FormBuilder,
    ngxService: NgxUiLoaderService
  ) {
    this.client = client;
    this.ngxService = ngxService;
    this.publicador = fb.group({
      primeiroNome: new FormControl("", Validators.required),
      ultimoNome: new FormControl("", Validators.required),
      email: new FormControl("", Validators.email),
      telefone: new FormControl(""),
      sexo: new FormControl("", Validators.required),
      privilegio: new FormControl("", Validators.required)
    });
  }

  ngOnInit() {}

  criarNovo({ value }: { value: CriarPublicadorCommand }) {
    this.loading = true;
    this.submited = true;
    this.ngxService.start();

    this.client.post(value).subscribe(
      info => {
        if (info.isSucceed) {
          this.result = true;
        } else {
          this.result = false;
        }
        this.loading = false;
        this.ngxService.stop();
      },
      error => {
        this.result = false;
        this.loading = false;
        this.erros = error.toString();
        this.ngxService.stop();
      }
    );

    this.ngxService.stop();
    this.loading = false;
  }

  limpar() {
    this.publicador.reset();
    this.submited = false;
    this.result = null;
  }
}
