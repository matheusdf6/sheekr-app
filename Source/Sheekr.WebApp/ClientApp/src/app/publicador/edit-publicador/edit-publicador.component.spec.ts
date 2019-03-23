import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditPublicadorComponent } from './edit-publicador.component';

describe('EditPublicadorComponent', () => {
  let component: EditPublicadorComponent;
  let fixture: ComponentFixture<EditPublicadorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditPublicadorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditPublicadorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
