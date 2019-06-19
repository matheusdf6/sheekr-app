import { Component, OnInit, ViewChild, ElementRef, ViewChildren, QueryList, AfterViewInit } from "@angular/core";
import { CriarPublicadorCommand, PublicadoresClient, SwaggerException, CriarAlunoCommand, AlunosClient, RequestInfo } from "src/app/sheekr-api";
import { FormGroup, FormControl, FormBuilder, Validators } from "@angular/forms";
import { NgxUiLoaderService } from "ngx-ui-loader";
import { ToastrService } from "ngx-toastr";
import { Router } from "@angular/router";
import { Location } from "@angular/common";

@Component({
  selector: "app-novo-publicador",
  templateUrl: "./novo-publicador.component.html",
  providers: [PublicadoresClient, AlunosClient],
  styleUrls: ["./novo-publicador.component.css"]
})
export class NovoPublicadorComponent implements AfterViewInit {
  @ViewChild("options") optionsTabRef: ElementRef;
  @ViewChildren("icon") iconRef: QueryList<ElementRef>;
  command: CriarPublicadorCommand = new CriarPublicadorCommand();
  pubClient: PublicadoresClient;
  aluCleint: AlunosClient;
  ngxService: NgxUiLoaderService;
  publicador: FormGroup;
  toastrService: ToastrService;
  result?: boolean;
  alunoSelected: boolean;
  erros: string = null;

  constructor(pubClient: PublicadoresClient, aluClient: AlunosClient, fb: FormBuilder, ngxService: NgxUiLoaderService, toastrService: ToastrService) {
    this.pubClient = pubClient;
    this.aluCleint = aluClient;
    this.ngxService = ngxService;
    this.toastrService = toastrService;
    this.publicador = fb.group({
      primeiroNome: new FormControl("", Validators.required),
      ultimoNome: new FormControl("", Validators.required),
      email: new FormControl("", Validators.email),
      telefone: new FormControl(""),
      sexo: new FormControl("", Validators.required),
      privilegio: new FormControl("", Validators.required),
      isAluno: new FormControl(false),
      alunoOptions: fb.group({
        fazLeitura: new FormControl(false),
        fazDemonstracao: new FormControl(false),
        fazDiscurso: new FormControl(false)
      }),
      isOrador: new FormControl(false),
      isDirigente: new FormControl(false)
    });
  }

  ngAfterViewInit(): void {
    console.log(this.iconRef);
  }

  criarNovo({ value }: { value: CriarPublicadorCommand }) {
    this.ngxService.start();
    let createAluno = this.publicador.get("isAluno").value == true;

    this.pubClient.post(value).subscribe(
      (info: RequestInfo) => {
        if (info.isSucceed) {
          if (createAluno && info.extras["id"]) {
            this.createAluno(info);
          }
          this.toastrService.success(`O publicador ${value.primeiroNome} foi adicionado a base de dados`, "Sucesso!");
        } else {
          this.toastrService.error(`Não foi possivel adicionar a base de dados`, "Erro!");
        }
        this.ngxService.stop();
      },
      error => {
        this.result = false;
        this.erros = error.toString();
        this.toastrService.error(`Não foi possivel adicionar a base de dados`, "Erro!");
        this.ngxService.stop();
      }
    );
  }

  addAluno(): void {
    let optionsTab: Element = this.optionsTabRef.nativeElement;
    let icon: Element = this.iconRef.toArray()[0].nativeElement;
    let isAlunoControl = this.publicador.get("isAluno") as FormControl;
    let alunoGroup = this.publicador.get("alunoOptions") as FormGroup;

    if (isAlunoControl.value == false) {
      isAlunoControl.setValue(true);
      this.alunoSelected = true;
      optionsTab.classList.add("show");
      icon.setAttribute("data-glyph", "x");
    } else {
      isAlunoControl.setValue(false);
      this.alunoSelected = false;
      alunoGroup.setValue({ fazLeitura: false, fazDemonstracao: false, fazDiscurso: false });
      optionsTab.classList.remove("show");
      optionsTab.parentElement.style.backgroundColor = "#00000000";
      icon.setAttribute("data-glyph", "plus");
    }
  }

  addOrador(): void {
    let isOradorControl = this.publicador.get("isOrador") as FormControl;
    let icon: Element = this.iconRef.toArray()[1].nativeElement;

    if (isOradorControl.value == false) {
      isOradorControl.setValue(true);
      icon.setAttribute("data-glyph", "x");
    } else {
      isOradorControl.setValue(false);
      icon.setAttribute("data-glyph", "plus");
    }
  }

  addDirigente(): void {
    let isDirigenteControl = this.publicador.get("isDirigente") as FormControl;
    let icon: Element = this.iconRef.toArray()[2].nativeElement;

    if (isDirigenteControl.value == false) {
      isDirigenteControl.setValue(true);
      icon.setAttribute("data-glyph", "x");
    } else {
      isDirigenteControl.setValue(false);
      icon.setAttribute("data-glyph", "plus");
    }
  }

  createAluno(info: RequestInfo) {
    let command = new CriarAlunoCommand();
    let alunoGroup = this.publicador.get("alunoOptions") as FormGroup;

    command.publicadorId = info.extras["id"];
    command.fazLeitura = alunoGroup.get("fazLeitura").value;
    command.fazDemonstracao = alunoGroup.get("fazDemonstracao").value;
    command.fazDiscurso = alunoGroup.get("fazDiscurso").value;

    this.aluCleint.post(command).subscribe(
      info => {
        if (info.isSucceed) {
          this.toastrService.success("O publicador foi adicionado a base de dados como aluno", "Sucesso!");
        } else {
          this.toastrService.error("Não foi possivel adicionar o aluno a base de dados", "Erro!");
        }
      },
      error => {
        this.toastrService.error("Não foi possivel adicionar o aluno a base de dados", "Erro!");
      }
    );
    return;
  }

  limpar() {
    this.publicador.reset();
  }
}
