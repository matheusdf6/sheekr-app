import { Component, OnInit, ViewChild, ElementRef } from "@angular/core";
import { SlideInOutAnimation } from "../animations";
import { EventEmitterService } from "../event-emitter.service";
import { CollapseCallback } from "../navbar/navbar.component";

@Component({
  selector: "app-side-menu",
  templateUrl: "./side-menu.component.html",
  styleUrls: ["./side-menu.component.css"],
  animations: [SlideInOutAnimation],
  providers: [EventEmitterService],
  host: {
    "(window:resize)": "onResize($event)"
  }
})
export class SideMenuComponent implements OnInit {
  @ViewChild("menu") menuRef: ElementRef;
  animationState: string;
  isSmallScreen: boolean;
  collapse: CollapseCallback = () =>
    (this.animationState = this.animationState === "out" ? "in" : "out");

  constructor() {
    if (window.innerWidth > 576) {
      this.animationState = "in";
      this.isSmallScreen = false;
    } else {
      this.animationState = "out";
      this.isSmallScreen = true;
    }
  }

  ngOnInit() {
    EventEmitterService.get("onCollapse").emit(this.collapse);
  }

  onResize(event) {
    if (event.target.innerWidth > 576) {
      this.animationState = "in";
      this.isSmallScreen = false;
    } else {
      this.animationState = "out";
      this.isSmallScreen = true;
    }
  }
}
