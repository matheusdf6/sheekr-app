import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListPublicadoresComponent } from './list-publicadores.component';

describe('ListPublicadoresComponent', () => {
  let component: ListPublicadoresComponent;
  let fixture: ComponentFixture<ListPublicadoresComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListPublicadoresComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListPublicadoresComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
