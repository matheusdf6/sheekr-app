import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NovoPublicadorComponent } from './novo-publicador.component';

describe('NovoPublicadorComponent', () => {
  let component: NovoPublicadorComponent;
  let fixture: ComponentFixture<NovoPublicadorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NovoPublicadorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NovoPublicadorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
