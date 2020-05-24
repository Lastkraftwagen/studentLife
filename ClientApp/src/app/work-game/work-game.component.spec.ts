import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkGameComponent } from './work-game.component';

describe('WorkGameComponent', () => {
  let component: WorkGameComponent;
  let fixture: ComponentFixture<WorkGameComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WorkGameComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkGameComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
