import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GameDesignComponent } from './game-design.component';

describe('GameDesignComponent', () => {
  let component: GameDesignComponent;
  let fixture: ComponentFixture<GameDesignComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GameDesignComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GameDesignComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
