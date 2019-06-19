import { Component, OnInit } from "@angular/core";
import { PublicadoresClient, PublicadorDetailModel, AtualizarPublicadorCommand, Genero, Privilegio } from "src/app/sheekr-api";
import { FormBuilder, FormGroup, Validators, FormControl } from "@angular/forms";
import { ActivatedRoute } from "@angular/router";
import { NgxUiLoaderService } from "ngx-ui-loader";
import { ToastrService, Toast } from "ngx-toastr";

@Component({
  selector: "app-edit-publicador",
  templateUrl: "./edit-publicador.component.html",
  providers: [PublicadoresClient],
  styleUrls: ["./edit-publicador.component.css"]
})
export class EditPublicadorComponent implements OnInit {
  client: PublicadoresClient;
  publicador: FormGroup;
  ngxLoader: NgxUiLoaderService;
  ngxToastr: ToastrService;
  publicadorId: number;
  publicadorModel: PublicadorDetailModel;
  route: ActivatedRoute;
  loading: boolean;
  submited: boolean;
  result: boolean;

  constructor(client: PublicadoresClient, private fb: FormBuilder, route: ActivatedRoute, ngxLoader: NgxUiLoaderService, ngxToastr: ToastrService) {
    this.client = client;
    this.ngxLoader = ngxLoader;
    this.ngxToastr = ngxToastr;
    this.route = route;
    this.publicador = fb.group({
      publicadorId: new FormControl(),
      primeiroNome: new FormControl("", Validators.required),
      ultimoNome: new FormControl("", Validators.required),
      email: new FormControl("", Validators.email),
      telefone: new FormControl(""),
      sexo: new FormControl("", Validators.required),
      privilegio: new FormControl("", Validators.required)
    });
  }

  ngOnInit() {
    this.publicadorId = Number(this.route.snapshot.paramMap.get("pub"));
    this.client.get(this.publicadorId).subscribe(info => {
      this.publicadorModel = info.response;

      this.publicador.patchValue({
        publicadorId: this.publicadorId,
        primeiroNome: this.publicadorModel.primeiroNome,
        ultimoNome: this.publicadorModel.ultimoNome,
        email: this.publicadorModel.email,
        telefone: this.publicadorModel.telefone,
        privilegio: Privilegio[this.publicadorModel.privilegio],
        sexo: Genero[this.publicadorModel.sexo]
      });
    });
  }

  atualizar({ value }: { value: PublicadorDetailModel }) {
    this.ngxLoader.start();

    let command = new AtualizarPublicadorCommand();
    command.publicadorId = this.publicadorId;
    command.primeiroNome = value.primeiroNome;
    command.ultimoNome = value.ultimoNome;
    command.email = value.email;
    command.telefone = value.telefone;
    command.sexo = Number(value.sexo);
    command.privilegio = Number(value.privilegio);

    this.client.put(this.publicadorId, command).subscribe(
      info => {
        if (info.isSucceed) {
          this.ngxToastr.success(`O publicador ${this.publicadorModel.nomeCompleto} foi atualizado`, "Sucesso!");
        } else {
          this.ngxToastr.error(`Não foi possivel atualizar`, "Erro!");
        }
        this.ngxLoader.stop();
      },
      error => {
        this.ngxToastr.error(`Não foi possivel atualizar`, "Erro!");
        this.ngxLoader.stop();
      }
    );
  }

  limpar() {
    this.publicador.reset();
  }
}
