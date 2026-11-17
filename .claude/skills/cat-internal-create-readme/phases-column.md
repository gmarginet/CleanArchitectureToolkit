# Phases column

Part of the `cat-internal-create-readme` skill. Read it when you add, change or recalculate a line of the `Phases` column of the repo overview.

The column has the header `Phases`, with one line for each phase in the plan of the item. A stable item has no plan, and its cell is empty. The lines of a cell are separated by `<br>`, and they are in the order of the priority number, the lowest first. So the first line is the next phase of the item to build, and the phase numbers of the lines can be out of sequence.

- A line looks like `[A (B): C](./plans/[[PlanFile]]#phase-A)`. A is the phase number, B is the number of open questions of the phase and C is the priority number of the phase. The link goes to the phase in the plan.
- The priority numbers are whole numbers from 1 and unique over the whole table, so there is one order of work. 1 is the highest priority.
- B counts the open questions of the phase. A question or a sub question counts when it has no answer and no sub question below it. A question that has a sub question does not count, because it is answered. The headings in a question region are `#### Question N`, `##### Question N.x` and `##### Answer N.x`.

## Ranking
- A phase that another phase needs ranks above it. Only the needs written in the `Needs` chapter of a phase count.
- Then the phase with fewer open questions comes first.
- On a tie, the phase that an earlier phase of the demo needs comes first.
- On a tie that is still open, the phase of the item that ranks higher in the table today keeps its place. For a new phase, use the alphabetical order of the name of the item.
- A phase that waits for something outside the repository, such as a stable release of another package, ranks after all other phases. These phases keep the same rules among themselves.
- A later phase of a plan can rank above an earlier phase of the same plan, when it has no written need on that phase.

## When to recalculate
- Recalculate the numbers every time a plan changes, an open question is answered, a plan is created or removed, or a build is finished. When a phase is removed, the numbers after it move up.
- The owner decides the order. Propose the new numbers with the reason when the order changes, and wait for the owner before you write them.
