import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EscolaDashComponent } from './escola-dash.component';

describe('EscolaDashComponent', () => {
  let component: EscolaDashComponent;
  let fixture: ComponentFixture<EscolaDashComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EscolaDashComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EscolaDashComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
