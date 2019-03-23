import { PublicadorModule } from "./publicador.module";

describe("PublicadorModuleModule", () => {
  let publicadorModule: PublicadorModule;

  beforeEach(() => {
    publicadorModule = new PublicadorModule();
  });

  it("should create an instance", () => {
    expect(publicadorModule).toBeTruthy();
  });
});
