import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DadosPublicadorComponent } from './dados-publicador.component';

describe('DadosPublicadorComponent', () => {
  let component: DadosPublicadorComponent;
  let fixture: ComponentFixture<DadosPublicadorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DadosPublicadorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DadosPublicadorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
