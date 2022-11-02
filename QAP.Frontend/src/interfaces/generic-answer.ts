/**
 * This is a TypeGen auto-generated file.
 * Any changes made to this file can be lost when this file is regenerated.
 */

import { AuthenticationAnswer } from "./authentication-answer";
import { AnswerMessage } from "./answer-message";

export interface GenericAnswer<T> {
    authenticationAnswer: AuthenticationAnswer;
    answerMessage: AnswerMessage;
    result: T;
}
