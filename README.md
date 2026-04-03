# Slot Machine – C# Windows Forms Game

A simple **Slot Machine** desktop game built using **C#** and **Windows Forms** in **Visual Studio**.

The project allows you:
- Spin slots with fruit symbols
- Manage credits, bets and wins
- Get free credit up to 4 times

---

## Game Overview

Slot Machine is a game played on **a set of slots**.  
Players press **Spin** to rotate the slots and try to match identical fruit symbols.

The game automatically detects:

- Matching symbols
- Wins and jackpot
- Credit deduction o losses

---

## Gameplay

- Each spin costs 5 credits.
- Wins are rewarded according to the fruit combination:
  - **seven.png** → JACKPOT (credits doubled)
  - Other fruits → fixed credit rewards
- Players can add free credits up to 4 times using the “Free Credits” button.
- The number of slots and fruits is selectable at startup.

---

## Game Logic

The slots are implemented using **PictureBoxes** dynamically created on the form.

The game logic includes:

- Timers controlling the slot spinning animation
- Random fruit selection for each slot
- Detection of matching symbols for wins
- Credit updates based on the spin outcome

---

## User Interface

The application uses **Windows Forms** and includes:

- PictureBoxes representing the slots
- Buttons for Spin and Free Credits
- Labels showing Credits, Bet, and Wins
---

## Technologies Used

- C#
- .NET Framework
- Windows Forms
- Visual Studio

---

## How to Run

1. Clone the repository

```bash
git clone https://github.com/mikegialelis/Slot-Machine
```
2. Open the project in Visual Studio
3. Place the required fruit images in the project folder:
**seven.png**, **cherry.png**, **diamond.png**, **gold.png**, **lemon.png**, **grape.png**
4. Run the project with F5
