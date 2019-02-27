import { Component, OnInit } from '@angular/core';
import { AlunosClient } from '../sheekr-api';

@Component({
  selector: 'app-list-alunos',
  templateUrl: './list-alunos.component.html',
  providers: [
    AlunosClient,
  ],
  styleUrls: ['./list-alunos.component.css']
})
export class ListAlunosComponent implements OnInit {

  constructor(client: AlunosClient) { }

  ngOnInit() {
  }

}
