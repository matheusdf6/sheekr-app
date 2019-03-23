import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { HomeComponent } from "./home/home.component";
import { ListAlunosComponent } from "./list-alunos/list-alunos.component";
import { NovoPublicadorComponent } from "./publicador/novo-publicador/novo-publicador.component";
import { ListPublicadoresComponent } from "./publicador/list-publicadores/list-publicadores.component";
import { EditPublicadorComponent } from "./publicador/edit-publicador/edit-publicador.component";

const routes: Routes = [
  { path: "", component: HomeComponent, pathMatch: "full" },
  { path: "list-alunos", component: ListAlunosComponent },
  {
    path: "publicador",
    component: ListPublicadoresComponent,
    pathMatch: "full"
  },
  { path: "publicador/novo", component: NovoPublicadorComponent },
  { path: "publicador/editar/:pub", component: EditPublicadorComponent }
];

@NgModule({
  exports: [RouterModule],
  imports: [RouterModule.forRoot(routes)]
})
export class AppRoutingModule {}
