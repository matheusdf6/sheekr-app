import { Component, OnInit } from "@angular/core";
import { AlunosClient, AlunoListViewModel } from "../sheekr-api";

@Component({
  selector: "list-alunos",
  templateUrl: "./list-alunos.component.html",
  providers: [AlunosClient],
  styleUrls: ["./list-alunos.component.css"]
})
export class ListAlunosComponent implements OnInit {
  vm: AlunoListViewModel;

  constructor(client: AlunosClient) {
    client.getAll().subscribe(
      result => {
        this.vm = result.response;
      },
      error => {
        console.log(error);
      }
    );
  }

  ngOnInit() {}
}
