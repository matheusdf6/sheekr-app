import { Component, OnInit, ViewChild, ViewChildren, ElementRef, QueryList } from "@angular/core";
import { PublicadoresClient, PublicadorListViewModel, PublicadorDetailModel, DeletarVariosPublicadorCommand } from "src/app/sheekr-api";
import { HumanizeService } from "src/app/humanize.service";
import { PublicadorSelectedArgs } from "../dados-publicador/dados-publicador.component";
import { EventEmitterService } from "src/app/event-emitter.service";
import { setTheme } from "ngx-bootstrap/utils";

@Component({
  selector: "app-list-publicadores",
  templateUrl: "./list-publicadores.component.html",
  providers: [PublicadoresClient, HumanizeService, EventEmitterService],
  styleUrls: ["./list-publicadores.component.css"],
  host: {
    "(window:resize)": "onResize($event)"
  }
})
export class ListPublicadoresComponent implements OnInit {
  // SERVICES
  client: PublicadoresClient;
  publicadores: PublicadorDetailModel[];
  humanizeService: HumanizeService;
  broadcastEmitter: EventEmitterService;

  // REFERENCES
  @ViewChild("tools") toolsRef: ElementRef;
  @ViewChildren("tool") toolListRef: QueryList<ElementRef>;
  @ViewChild("toolsContainer") toolsContainerRef: ElementRef;

  // STATE VARIABLES
  modalOpen: boolean = false;
  tooltipDisable = false;
  toDeleteId: number;
  toDeleteIndex: number;
  checkedIndexes: Array<number> = new Array<number>();
  checkedIds: Array<number> = new Array<number>();

  constructor(client: PublicadoresClient, humanizeService: HumanizeService) {
    setTheme("bs3");
    this.client = client;
    this.humanizeService = humanizeService;
  }

  ngOnInit() {
    this.client.getAll().subscribe(
      list => {
        this.publicadores = list.response.publicadores;
      },
      error => {
        console.log(error);
      }
    );

    let tools: Element = this.toolsRef.nativeElement;
    let toolsContainer: Element = this.toolsContainerRef.nativeElement;

    if (window.innerWidth < 640) {
      toolsContainer.className = "floating-menu";
      this.tooltipDisable = false;
    } else {
      toolsContainer.className = "app-toolbar";
      this.tooltipDisable = true;
    }
  }

  onSelect({ index, publicador }: PublicadorSelectedArgs): void {
    if (this.checkedIndexes.includes(index) && this.checkedIds.includes(publicador.publicadorId)) {
      let arrayIndex_Index = this.checkedIndexes.indexOf(index);
      this.checkedIndexes.splice(arrayIndex_Index, 1);
      let arrayIndex_Id = this.checkedIds.indexOf(publicador.publicadorId);
      this.checkedIds.splice(arrayIndex_Id, 1);
    } else {
      this.checkedIds.push(publicador.publicadorId);
      this.checkedIndexes.push(index);
    }
    console.log(`Array de Ids: ${this.checkedIds} \nArray de Index: ${this.checkedIndexes}`);
  }

  onResize(event) {
    let tools: Element = this.toolsRef.nativeElement;
    let toolsContainer: Element = this.toolsContainerRef.nativeElement;
    let toolList: Element[] = this.toolListRef.toArray().map(i => i.nativeElement);

    if (event.target.innerWidth < 640) {
      toolsContainer.className = "floating-menu";
      this.tooltipDisable = false;
    } else {
      toolsContainer.className = "app-toolbar";
      this.tooltipDisable = true;
    }
  }

  exibirFloatMenu() {
    let tools: Element = this.toolsRef.nativeElement;
    tools.classList.contains("show") ? tools.classList.remove("show") : tools.classList.add("show");
  }

  abrirModal() {
    this.modalOpen = true;
  }

  fecharGuias() {
    EventEmitterService.get("fecharGuias").emit();
  }

  fechar() {
    this.modalOpen = false;
  }

  excluir() {
    let command = new DeletarVariosPublicadorCommand();
    command.publicadorIds = this.checkedIds;
    this.client.deleteMany(command).subscribe(info => console.log(info.isSucceed), error => console.error(error));
    this.checkedIndexes.forEach(index => {
      this.publicadores.splice(index, 1);
    });
    this.checkedIndexes = new Array<number>();
    this.checkedIds = new Array<number>();
    this.fechar();
  }

  checkPublicador(index: number, id: number) {
    if (this.checkedIndexes.includes(index) && this.checkedIds.includes(id)) {
      let arrayIndex_Index = this.checkedIndexes.indexOf(index);
      this.checkedIndexes.splice(arrayIndex_Index, 1);
      let arrayIndex_Id = this.checkedIds.indexOf(id);
      this.checkedIds.splice(arrayIndex_Id, 1);
    } else {
      this.checkedIndexes.push(index);
      this.checkedIds.push(id);
    }
  }
}
