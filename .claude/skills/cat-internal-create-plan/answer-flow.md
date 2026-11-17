# Answer process flow

Part of the `cat-internal-create-plan` skill. The templates named here are in [plan.parts.template.md](plan.parts.template.md).

New questions and sub questions go only in the plan. The reply to the owner names the question numbers and never repeats the questions.

These rules apply to every question region:
- Everything about one question stays inside its `Question N` region, in the order it happens, so the region holds the full history.
- A new question or answer is always added at the end of the region, just before the end marker.
- Sub questions and their answers get the numbers N.1, N.1.1 and so on, all with the same heading level as the first answer.
- Never change or remove an answer while the question is open.
- If an answer is not enough, always add a sub question for the open part.

The outcomes of the answer:
- A. The answer closes the question, including all the sub questions.
  - Incorporate the outcome of the question into the description of the phase, in the `PhaseDescription` region of the phase the question belongs to.
  - Then remove the question chapter that is now fully answered.
- B. The answer is not clear enough and results in a sub question.
  - Create one or more sub questions by using the `SubQuestion` template.
  - The owner answers a sub question by creating a new chapter at the end of the question region, with a title like the `SubAnswerTitle` template.
  - When Claude processes this answer there are the same 3 possible outcomes: A, B and C. Use this answer process flow to continue.
- C. The owner asks to move this to another phase.
  - If the phase the owner asks to move it to does not exist, first create the phase as the chapter "Phases" of the `SKILL.md` describes.
  - Then look at what is still open in the question region.
  - If nothing is answered yet, copy the full question region, including all the sub questions and keeping its number, to that phase. Then remove it from the current phase.
  - If part is answered:
    - Incorporate the answered parts into the description of the current phase, like outcome A.
    - The answer says what to do with the rest: add it to the description of the other phase, or add it as an open question of the other phase.
    - An open question gets a new number and the `OpenQuestion` template, and must make sense on its own.
    - Then remove the original question region from the current phase.
