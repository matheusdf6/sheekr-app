import { TestBed, inject } from "@angular/core/testing";

import { HumanizeService } from "./humanize.service";

describe("HumanizeServiceService", () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [HumanizeService]
    });
  });

  it("should be created", inject(
    [HumanizeService],
    (service: HumanizeService) => {
      expect(service).toBeTruthy();
    }
  ));
});
