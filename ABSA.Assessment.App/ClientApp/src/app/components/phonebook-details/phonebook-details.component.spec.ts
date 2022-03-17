import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PhonebookDetailsComponent } from './phonebook-details.component';

describe('PhonebookDetailsComponent', () => {
  let component: PhonebookDetailsComponent;
  let fixture: ComponentFixture<PhonebookDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PhonebookDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PhonebookDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
