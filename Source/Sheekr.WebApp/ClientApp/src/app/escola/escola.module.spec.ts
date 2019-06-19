import { EscolaModule } from "./escola.module";

describe("EscolaModule", () => {
  let escolaModule: EscolaModule;

  beforeEach(() => {
    escolaModule = new EscolaModule();
  });

  it("should create an instance", () => {
    expect(escolaModule).toBeTruthy();
  });
});
