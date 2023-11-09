import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RoleMockTogglerComponent } from './role-mock-toggler.component';

describe('RoleMockTogglerComponent', () => {
  let component: RoleMockTogglerComponent;
  let fixture: ComponentFixture<RoleMockTogglerComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [RoleMockTogglerComponent]
    });
    fixture = TestBed.createComponent(RoleMockTogglerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
