import { Injectable } from "@angular/core";

@Injectable({
  providedIn: "root"
})
export class HumanizeService {
  constructor() {}

  humanizeCamelCase(str: string): string {
    return str
      .replace(/([A-Z])/g, " $1")
      .replace(/^./, str => str.toUpperCase());
  }
}
