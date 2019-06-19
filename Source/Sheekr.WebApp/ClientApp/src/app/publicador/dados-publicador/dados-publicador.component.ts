import { Component, OnInit, Input, Output, EventEmitter, ViewChild, ElementRef } from "@angular/core";
import { PublicadorDetailModel } from "src/app/sheekr-api";
import { EventEmitterService } from "src/app/event-emitter.service";

@Component({
  selector: "app-dados-publicador",
  templateUrl: "./dados-publicador.component.html",
  providers: [EventEmitterService],
  styleUrls: ["./dados-publicador.component.css"]
})
export class DadosPublicadorComponent implements OnInit {
  @ViewChild("cardBody") cardBodyElementRef: ElementRef;
  @Input() publicador: PublicadorDetailModel;
  @Input() index: number;
  @Output() selectedPublicador: EventEmitter<PublicadorSelectedArgs>;
  private selected: boolean;

  constructor() {
    this.selectedPublicador = new EventEmitter<PublicadorSelectedArgs>();
  }

  ngOnInit() {
    EventEmitterService.get("fecharGuias").subscribe(() => this.fecharGuias());
  }

  onSelect(): void {
    this.selectedPublicador.emit({
      publicador: this.publicador,
      index: this.index
    });
  }

  fecharGuias(): void {
    let classAttr = this.cardBodyElementRef.nativeElement.classList;
    if (classAttr.contains("show")) classAttr.remove("show");
  }

  exibirDetalhes(): void {
    let classAttr = this.cardBodyElementRef.nativeElement.classList;
    classAttr.contains("show") ? classAttr.remove("show") : classAttr.add("show");
  }

  getPrivilegio(): string {
    if (this.publicador.privilegio == "Nenhum") return "";
    if (this.publicador.privilegio == "ServoMinisterial") return "Servo Ministerial";
    if (this.publicador.privilegio == "Anciao") return "Ancião";
    return this.publicador.privilegio;
  }

  hasInformacoes(): boolean {
    return this.publicador.isAluno || this.publicador.isDirigente || this.publicador.isOrador;
  }
}

export interface PublicadorSelectedArgs {
  publicador: PublicadorDetailModel;
  index: number;
}
