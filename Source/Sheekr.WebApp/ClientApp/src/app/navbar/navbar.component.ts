import { Component, OnInit } from "@angular/core";
import { UsuarioDto, UsuariosClient } from "../sheekr-api";
import { EventEmitterService } from "../event-emitter.service";

@Component({
  selector: "app-navbar",
  templateUrl: "./navbar.component.html",
  providers: [EventEmitterService],
  styleUrls: ["./navbar.component.css"]
})
export class NavbarComponent implements OnInit {
  imagePath: string = "../../assets/logo.svg";
  user: UsuarioDto;
  role: string = "ADMINISTRADOR";
  collapse: CollapseCallback;

  constructor() {}

  ngOnInit() {
    EventEmitterService.get("onCollapse").subscribe(
      emitted => (this.collapse = emitted)
    );
    this.user = new UsuarioDto();
    this.user.userName = "Matheus Darós";
  }

  collapseMenu() {
    this.collapse();
  }
}

export interface CollapseCallback {
  (): void;
}
