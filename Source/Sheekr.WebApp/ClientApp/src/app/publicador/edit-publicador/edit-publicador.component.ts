import { Component, OnInit } from "@angular/core";
import {
  PublicadoresClient,
  PublicadorDetailModel,
  AtualizarPublicadorCommand,
  Genero,
  Privilegio
} from "src/app/sheekr-api";
import {
  FormBuilder,
  FormGroup,
  Validators,
  FormControl
} from "@angular/forms";
import { ActivatedRoute } from "@angular/router";
import { NgxUiLoaderService } from "ngx-ui-loader";

@Component({
  selector: "app-edit-publicador",
  templateUrl: "./edit-publicador.component.html",
  providers: [PublicadoresClient],
  styleUrls: ["./edit-publicador.component.css"]
})
export class EditPublicadorComponent implements OnInit {
  client: PublicadoresClient;
  publicador: FormGroup;
  ngxService: NgxUiLoaderService;
  publicadorId: number;
  publicadorModel: PublicadorDetailModel;
  route: ActivatedRoute;
  loading: boolean;
  submited: boolean;
  result: boolean;

  constructor(
    client: PublicadoresClient,
    private fb: FormBuilder,
    route: ActivatedRoute,
    ngxService: NgxUiLoaderService
  ) {
    this.client = client;
    this.ngxService = ngxService;
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
    this.loading = true;
    this.submited = true;
    this.ngxService.start();

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
        this.ngxService.stop();
        console.log(error);
      }
    );

    this.ngxService.stop();
    this.loading = false;
  }

  limpar() {
    this.publicador.reset();
  }
}
