import { Component, OnInit, ViewChild, ElementRef } from "@angular/core";
import {
  PublicadoresClient,
  PublicadorListViewModel,
  PublicadorDetailModel,
  DeletarVariosPublicadorCommand
} from "src/app/sheekr-api";
import { HumanizeService } from "src/app/humanize.service";

@Component({
  selector: "app-list-publicadores",
  templateUrl: "./list-publicadores.component.html",
  providers: [PublicadoresClient, HumanizeService],
  styleUrls: ["./list-publicadores.component.css"]
})
export class ListPublicadoresComponent implements OnInit {
  modalOpen: boolean = false;
  client: PublicadoresClient;
  publicadores: PublicadorDetailModel[];
  humanizeService: HumanizeService;
  toDeleteId: number;
  toDeleteIndex: number;
  checkedIndexes: Array<number> = new Array<number>();
  checkedIds: Array<number> = new Array<number>();

  constructor(client: PublicadoresClient, humanizeService: HumanizeService) {
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
  }

  abrirModal() {
    this.modalOpen = true;
  }

  fechar() {
    this.modalOpen = false;
  }

  excluir() {
    let command = new DeletarVariosPublicadorCommand();
    command.publicadorIds = this.checkedIds;
    this.client
      .deleteMany(command)
      .subscribe(
        info => console.log(info.isSucceed),
        error => console.error(error)
      );
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
