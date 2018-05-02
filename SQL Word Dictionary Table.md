### SQL Meta Data
```sql_raw_table
DROP TABLE IF EXISTS tbl_metadata;
CREATE TABLE IF NOT EXISTS tbl_metadata
(
    tm_meta_ref_id                  BIGINT(20) NULL,
    tm_meta_id                      BIGINT(20) NOT NULL,
    tm_meta_identity                TEXT NULL,
    tm_meta_key                     TEXT NOT NULL,
    tm_meta_value                   TEXT NULL,
    CONSTRAINT pk_tm_tm_meta_id PRIMARY KEY (tm_meta_id)
) ENGINE=InnoDB DEFAULT CHARACTER SET=utf8;
INSERT INTO tbl_metadata VALUES(null, 15250246021236, null, 'selected_lan', '15250225243159');
```
### SQL Word Dictionary
```sql_word_dcitionary
DROP TABLE IF EXISTS tbl_language;
CREATE TABLE IF NOT EXISTS tbl_language
(
    lng_lang_id                     BIGINT(20)        NOT NULL,
    lng_lang_name                   VARCHAR(255)      NULL,
    CONSTRAINT                      pk_language_lng_lang_id PRIMARY KEY (lng_lang_id)
) ENGINE=InnoDB DEFAULT CHARACTER SET=utf8;
DELETE FROM tbl_language;
INSERT INTO tbl_language VALUES(15250225243159, 'Bangla');
INSERT INTO tbl_language VALUES(15250225282648, 'English');

DROP TABLE IF EXISTS tbl_word_list;
CREATE TABLE IF NOT EXISTS tbl_word_list
(
    -- lng_lang_id                     BIGINT(20)        NOT NULL,
    wrd_word_id                     BIGINT(20)        NOT NULL,
    wrd_word_text                   TEXT              NOT NULL,
	wrd_word_part_speech            VARCHAR(255)      NULL,
	wrd_word_description            TEXT              NULL,
	wrd_word_sentence               TEXT              NULL,
    CONSTRAINT                      pk_word_list_wrd_word_id PRIMARY KEY (wrd_word_id)
) ENGINE=InnoDB DEFAULT CHARACTER SET=utf8;
-- https://www.ef.com/english-resources/english-vocabulary/top-1000-words/
-- http://www.english-bangla.com/dictionary/able
-- http://www.banglaconverter.net/tools.php?f=Unicode-To-Bijoy
-- http://learnersdictionary.com/3000-words/alpha/a
-- INSERT INTO tbl_word_list VALUES(15251198029556, 'Actually', null, null, null);
DELETE FROM tbl_word_list;
INSERT INTO tbl_word_list VALUES(15250260323147, 'Ability', null, null, null);
INSERT INTO tbl_word_list VALUES(15250260362542, 'Able', null, null, null);
INSERT INTO tbl_word_list VALUES(15250260431128, 'About', null, null, null);
INSERT INTO tbl_word_list VALUES(15250260521997, 'Above', null, null, null);
INSERT INTO tbl_word_list VALUES(15250260603556, 'Accept', null, null, null);

INSERT INTO tbl_word_list VALUES(15250260666810, 'According', null, null, null);
INSERT INTO tbl_word_list VALUES(15251109514631, 'Account', null, null, null);
INSERT INTO tbl_word_list VALUES(15251109546203, 'Across', null, null, null);
INSERT INTO tbl_word_list VALUES(15251109633160, 'Act', null, null, null);
INSERT INTO tbl_word_list VALUES(15251109712687, 'Action', null, null, null);

INSERT INTO tbl_word_list VALUES(15251109797478, 'Activity', null, null, null);
INSERT INTO tbl_word_list VALUES(15251198058825, 'Add', null, null, null);
INSERT INTO tbl_word_list VALUES(15251198141727, 'Address', null, null, null);
INSERT INTO tbl_word_list VALUES(15251198225209, 'Administration', null, null, null);
INSERT INTO tbl_word_list VALUES(15251894778533, 'Admit', null, null, null);

INSERT INTO tbl_word_list VALUES(15251896965769, 'Adult', null, null, null);
INSERT INTO tbl_word_list VALUES(15251897223567, 'Affect', null, null, null);
INSERT INTO tbl_word_list VALUES(15251897303052, 'After', null, null, null);
INSERT INTO tbl_word_list VALUES(15251897396232, 'Again', null, null, null);
INSERT INTO tbl_word_list VALUES(15251897466111, 'Against', null, null, null);

INSERT INTO tbl_word_list VALUES(15251897539967, 'Age', null, null, null);
INSERT INTO tbl_word_list VALUES(15251994021781, 'Agency', null, null, null);
INSERT INTO tbl_word_list VALUES(15251994062673, 'Agent', null, null, null);
INSERT INTO tbl_word_list VALUES(15251994199344, 'Ago', null, null, null);
INSERT INTO tbl_word_list VALUES(15251994274772, 'Agree', null, null, null);

INSERT INTO tbl_word_list VALUES(15251994349647, 'Agreement', null, null, null);
INSERT INTO tbl_word_list VALUES(15251994593125, 'Ahead', null, null, null);
INSERT INTO tbl_word_list VALUES(15251994668336, 'Air', null, null, null);
INSERT INTO tbl_word_list VALUES(15251994745490, 'All', null, null, null);
INSERT INTO tbl_word_list VALUES(15251994838459, 'Allow', null, null, null);

INSERT INTO tbl_word_list VALUES(15252372456513, 'Almost', null, null, null);
INSERT INTO tbl_word_list VALUES(15252372513134, 'Alone', null, null, null);
INSERT INTO tbl_word_list VALUES(15252372803874, 'Along', null, null, null);
INSERT INTO tbl_word_list VALUES(15252372921172, 'Already', null, null, null);
INSERT INTO tbl_word_list VALUES(15252373058359, 'Also', null, null, null);

INSERT INTO tbl_word_list VALUES(15252373201211, 'Although', null, null, null);
INSERT INTO tbl_word_list VALUES(15252373376620, 'Always', null, null, null);
INSERT INTO tbl_word_list VALUES(15252373486255, 'Among', null, null, null);
INSERT INTO tbl_word_list VALUES(15252385435251, 'Amongst', null, null, null);
INSERT INTO tbl_word_list VALUES(15252373601170, 'Amount', null, null, null);

INSERT INTO tbl_word_list VALUES(15252373751368, 'Analysis', null, null, null);
INSERT INTO tbl_word_list VALUES(15252558318715, 'And', null, null, null);
INSERT INTO tbl_word_list VALUES(15252558358790, 'Animal', null, null, null);
INSERT INTO tbl_word_list VALUES(15252558442069, 'Another', null, null, null);
INSERT INTO tbl_word_list VALUES(15252558515898, 'Answer', null, null, null);

INSERT INTO tbl_word_list VALUES(15252558645441, 'Any', null, null, null);
INSERT INTO tbl_word_list VALUES(15252558686948, 'Anyone', null, null, null);
INSERT INTO tbl_word_list VALUES(15252558754270, 'Anything', null, null, null);
INSERT INTO tbl_word_list VALUES(15252558833740, 'Appear', null, null, null);
INSERT INTO tbl_word_list VALUES(15252558893476, 'Apply', null, null, null);

INSERT INTO tbl_word_list VALUES(88888888888, 'aaaaaaaaaa', null, null, null);
DROP TABLE IF EXISTS tbl_spelling_list;
CREATE TABLE IF NOT EXISTS tbl_spelling_list
(
    lng_lang_id                     BIGINT(20)        NOT NULL,
    wrd_word_id                     BIGINT(20)        NOT NULL,
    spl_spel_id                     BIGINT(20)        NOT NULL,
    spl_spel_text                   TEXT              NOT NULL,
    CONSTRAINT                      pk_spelling_list_spl_spel_id PRIMARY KEY (spl_spel_id)
) ENGINE=InnoDB DEFAULT CHARACTER SET=utf8;
DELETE FROM tbl_spelling_list;
INSERT INTO tbl_spelling_list VALUES(15250225243159, 15250260323147, 15250225243159, 'A¨vwe''wjwU');
INSERT INTO tbl_spelling_list VALUES(15250225243159, 15250260362542, 15250273252534, 'Ge''j&');
INSERT INTO tbl_spelling_list VALUES(15250225243159, 15250260431128, 15250281503910, 'A¨vevDU&');
INSERT INTO tbl_spelling_list VALUES(15250225243159, 15250260521997, 15251105608094, 'A¨vevf&');
INSERT INTO tbl_spelling_list VALUES(15250225243159, 15250260603556, 15251105636819, 'A¨vK&''‡mÞ&');

INSERT INTO tbl_spelling_list VALUES(15250225243159, 15250260666810, 15251105824523, 'A¨v‡Kv''wWO&');
INSERT INTO tbl_spelling_list VALUES(15250225243159, 15251109514631, 15251124403733, 'A¨vKvDbU');
INSERT INTO tbl_spelling_list VALUES(15250225243159, 15251109546203, 15251124445086, 'A¨v‡µvm');
INSERT INTO tbl_spelling_list VALUES(15250225243159, 15251109633160, 15251124564261, 'A¨vKU&');
INSERT INTO tbl_spelling_list VALUES(15250225243159, 15251109712687, 15251124695026, 'A¨vK&kb&');

INSERT INTO tbl_spelling_list VALUES(15250225243159, 15251109797478, 15251124824082, 'A¨vKwUwfwU');
INSERT INTO tbl_spelling_list VALUES(15250225243159, 15251198058825, 15251894077354, 'A¨vW');
INSERT INTO tbl_spelling_list VALUES(15250225243159, 15251198141727, 15251894183706, 'A¨v‡W«m&');
INSERT INTO tbl_spelling_list VALUES(15250225243159, 15251198225209, 15251894224481, 'A¨vwW&gwbm‡U«Bkb&');
INSERT INTO tbl_spelling_list VALUES(15250225243159, 15251894778533, 15251896898853, 'A¨vWwgU&');

INSERT INTO tbl_spelling_list VALUES(15250225243159, 15251896965769, 15251906224926, 'A¨vWvjU&');
INSERT INTO tbl_spelling_list VALUES(15250225243159, 15251897223567, 15251906269272, 'A¨v‡dKU&');
INSERT INTO tbl_spelling_list VALUES(15250225243159, 15251897303052, 15251906425289, 'AvtdUv(i)');
INSERT INTO tbl_spelling_list VALUES(15250225243159, 15251897396232, 15251906738383, 'G‡Mb&');
INSERT INTO tbl_spelling_list VALUES(15250225243159, 15251897466111, 15251906812251, 'G‡MbmU&');

INSERT INTO tbl_spelling_list VALUES(15250225243159, 15251897539967, 15252000848091, 'GBR&');
INSERT INTO tbl_spelling_list VALUES(15250225243159, 15251994021781, 15252000874337, 'GB‡Rbwm');
INSERT INTO tbl_spelling_list VALUES(15250225243159, 15251994062673, 15252001004714, 'G‡RbU&');
INSERT INTO tbl_spelling_list VALUES(15250225243159, 15251994199344, 15252001122230, 'G‡MŠ');
INSERT INTO tbl_spelling_list VALUES(15250225243159, 15251994274772, 15252001237545, 'GMix');

INSERT INTO tbl_spelling_list VALUES(15250225243159, 15251994349647, 15252007093577, 'GMixg¨vbU&');
INSERT INTO tbl_spelling_list VALUES(15250225243159, 15251994593125, 15252007136891, 'G‡nW&');
INSERT INTO tbl_spelling_list VALUES(15250225243159, 15251994668336, 15252007238533, 'GAv(i)');
INSERT INTO tbl_spelling_list VALUES(15250225243159, 15251994745490, 15252007335176, 'Aj&');
INSERT INTO tbl_spelling_list VALUES(15250225243159, 15251994838459, 15252007436111, 'G¨jvD');

INSERT INTO tbl_spelling_list VALUES(15250225243159, 15252372456513, 15252388184312, 'Aj‡gŠmU&');
INSERT INTO tbl_spelling_list VALUES(15250225243159, 15252372513134, 15252388215399, 'G¨‡jŠb&');
INSERT INTO tbl_spelling_list VALUES(15250225243159, 15252372803874, 15252388315261, 'G¨‡jvO&');
INSERT INTO tbl_spelling_list VALUES(15250225243159, 15252372921172, 15252388433926, 'Aj‡iwW');
INSERT INTO tbl_spelling_list VALUES(15250225243159, 15252373058359, 15252388525535, 'Aj‡mŠ');

INSERT INTO tbl_spelling_list VALUES(15250225243159, 15252373201211, 15252388604982, 'Aj‡`Š');
INSERT INTO tbl_spelling_list VALUES(15250225243159, 15252373376620, 15252388689028, 'AjI‡qR&');
INSERT INTO tbl_spelling_list VALUES(15250225243159, 15252373486255, 15252388772126, 'G¨gO&');
INSERT INTO tbl_spelling_list VALUES(15250225243159, 15252373601170, 15252388867633, 'G¨gOmU&');
INSERT INTO tbl_spelling_list VALUES(15250225243159, 15252373601170, 15252388953623, 'G¨gvDbU&');

INSERT INTO tbl_spelling_list VALUES(15250225243159, 15252373751368, 15252389043642, 'G¨b¨vjvwmm&');
INSERT INTO tbl_spelling_list VALUES(15250225243159, 15252558318715, 15252574608853, 'A¨bW&');
INSERT INTO tbl_spelling_list VALUES(15250225243159, 15252558358790, 15252574656706, 'A¨vwbg¨vj&‌');
INSERT INTO tbl_spelling_list VALUES(15250225243159, 15252558442069, 15252574753142, 'A¨vbv`v(i)');
INSERT INTO tbl_spelling_list VALUES(15250225243159, 15252558515898, 15252574911717, 'A¨vbmv(i)');

INSERT INTO tbl_spelling_list VALUES(15250225243159, 15252558645441, 15252575007469, 'Gwb');
INSERT INTO tbl_spelling_list VALUES(15250225243159, 15252558686948, 15252575104041, 'GwbIAvb&');
INSERT INTO tbl_spelling_list VALUES(15250225243159, 15252558754270, 15252575238338, 'Gwbw_O&');
INSERT INTO tbl_spelling_list VALUES(15250225243159, 15252558833740, 15252575324513, 'A¨vwcAv(i)');
INSERT INTO tbl_spelling_list VALUES(15250225243159, 15252558893476, 15252575417466, 'A¨vc­vB');


INSERT INTO tbl_spelling_list VALUES(15250225243159, 11222222, 1111111, 'aaaaaaaaaa');

DROP TABLE IF EXISTS tbl_meaning_list;
CREATE TABLE IF NOT EXISTS tbl_meaning_list
(
    lng_lang_id                     BIGINT(20)        NOT NULL,
    wrd_word_id                     BIGINT(20)        NOT NULL,
    mng_meaning_id                  BIGINT(20)        NOT NULL,
    mng_meaning_text                TEXT              NOT NULL,
    CONSTRAINT                      pk_meaning_list_mng_meaning_id PRIMARY KEY (mng_meaning_id)
) ENGINE=InnoDB DEFAULT CHARACTER SET=utf8;
DELETE FROM tbl_meaning_list;
INSERT INTO tbl_meaning_list VALUES(15250225243159, 15250260323147, 15250225243159, 'Kg©`¶Zv; kw³; ‰bcyY¨');
INSERT INTO tbl_meaning_list VALUES(15250225243159, 15250260362542, 15250273252534, 'mg_©; `¶; axkw³m¤úbœ');
INSERT INTO tbl_meaning_list VALUES(15250225243159, 15250260431128, 15250281503910, 'PZyw`©‡K; wbhy³; e¨vc…Z; Db¥yL; BZ¯—Zt; wbK‡U; m¤^‡Ü; c«vq; KvQvKvwQ');
INSERT INTO tbl_meaning_list VALUES(15250225243159, 15250260521997, 15251105608094, 'Dc‡i; KvnviI A‡c¶v E‡aŸ©; AwaKZi; QvovBqv');
INSERT INTO tbl_meaning_list VALUES(15250225243159, 15250260603556, 15251105636819, 'M«nY Kiv; m¤§Z nIqv; ¯^xKvi Kiv');

INSERT INTO tbl_meaning_list VALUES(15250225243159, 15250260666810, 15251105824523, 'Abyhvqx; Abymv‡i');
INSERT INTO tbl_meaning_list VALUES(15250225243159, 15251109514631, 15251124403733, 'MYbv; wnmve; wnmve Kiv; we‡ePbv Kiv');
INSERT INTO tbl_meaning_list VALUES(15250225243159, 15251109546203, 15251124445086, 'Aci cv‡i');
INSERT INTO tbl_meaning_list VALUES(15250225243159, 15251109633160, 15251124564261, 'KvR; fvb Kiv');
INSERT INTO tbl_meaning_list VALUES(15250225243159, 15251109712687, 15251124695026, 'Kvh©; wµqvdj');

INSERT INTO tbl_meaning_list VALUES(15250225243159, 15251109797478, 15251124824082, 'mwµqZv; Kg©ZrciZv');
INSERT INTO tbl_meaning_list VALUES(15250225243159, 15251198058825, 15251894077354, '‡hvMKiv; GKÎ Kiv');
INSERT INTO tbl_meaning_list VALUES(15250225243159, 15251198141727, 15251894183706, 'wVKvbv; m‡¤^vab Kiv; fvlY †`Iqv');
INSERT INTO tbl_meaning_list VALUES(15250225243159, 15251198225209, 15251894224481, 'kvmb Kvh©');
INSERT INTO tbl_meaning_list VALUES(15250225243159, 15251894778533, 15251896898853, 'fwZ© Kiv');

INSERT INTO tbl_meaning_list VALUES(15250225243159, 15251896965769, 15251906224926, 'eq¯‹');
INSERT INTO tbl_meaning_list VALUES(15250225243159, 15251897223567, 15251906269272, 'cwieZ©b mvab Kiv');
INSERT INTO tbl_meaning_list VALUES(15250225243159, 15251897303052, 15251906425289, 'c‡i');
INSERT INTO tbl_meaning_list VALUES(15250225243159, 15251897396232, 15251906738383, 'Avevi');
INSERT INTO tbl_meaning_list VALUES(15250225243159, 15251897466111, 15251906812251, 'wei“‡×');

INSERT INTO tbl_meaning_list VALUES(15250225243159, 15251897539967, 15252000848091, 'eqm');
INSERT INTO tbl_meaning_list VALUES(15250225243159, 15251994021781, 15252000874337, 'gva¨g');
INSERT INTO tbl_meaning_list VALUES(15250225243159, 15251994062673, 15252001004714, 'c«wZwbwa');
INSERT INTO tbl_meaning_list VALUES(15250225243159, 15251994199344, 15252001122230, 'AZx‡Z');
INSERT INTO tbl_meaning_list VALUES(15250225243159, 15251994274772, 15252001237545, 'm¤§Z nIqv');

INSERT INTO tbl_meaning_list VALUES(15250225243159, 15251994349647, 15252007093577, 'Pyw³; gZ; wgj; m¤§wZ');
INSERT INTO tbl_meaning_list VALUES(15250225243159, 15251994593125, 15252007136891, 'm¤§y‡L');
INSERT INTO tbl_meaning_list VALUES(15250225243159, 15251994668336, 15252007238533, 'evqy');
INSERT INTO tbl_meaning_list VALUES(15250225243159, 15251994745490, 15252007335176, '‡gv‡Ui Dci; me; mKj');
INSERT INTO tbl_meaning_list VALUES(15250225243159, 15251994838459, 15252007436111, 'Aby‡gv`b Kiv');

INSERT INTO tbl_meaning_list VALUES(15250225243159, 15252372456513, 15252388184312, 'c«vq; A‡bKvs‡k');
INSERT INTO tbl_meaning_list VALUES(15250225243159, 15252372513134, 15252388215399, 'GKv; GKvKx; †Kej; GKKfv‡e; GKgvÎ; wb:m½fv‡e; wb:m½; gvÎ BnvB; GKv GKv; wbtm½; m½xnxb; ïay wb‡R');
INSERT INTO tbl_meaning_list VALUES(15250225243159, 15252372803874, 15252388315261, '‡Kej; GKvKx; wbtm½');
INSERT INTO tbl_meaning_list VALUES(15250225243159, 15252372921172, 15252388433926, 'B‡Zvg‡a¨; B‡Zvc~‡e©');
INSERT INTO tbl_meaning_list VALUES(15250225243159, 15252373058359, 15252388525535, 'AviI; †mBi“c');

INSERT INTO tbl_meaning_list VALUES(15250225243159, 15252373201211, 15252388604982, 'm‡Ë¡I; hw`I');
INSERT INTO tbl_meaning_list VALUES(15250225243159, 15252373376620, 15252388689028, 'me©`v; wPiš—b');
INSERT INTO tbl_meaning_list VALUES(15250225243159, 15252373486255, 15252388772126, 'A‡b‡Ki ev eûi g‡a¨');
INSERT INTO tbl_meaning_list VALUES(15250225243159, 15252373601170, 15252388867633, 'g‡a¨; Aš—‡i; wfZ‡i');
INSERT INTO tbl_meaning_list VALUES(15250225243159, 15252373601170, 15252388953623, '‡gvU cwigvY');

INSERT INTO tbl_meaning_list VALUES(15250225243159, 15252373751368, 15252389043642, 'we‡klY');
INSERT INTO tbl_meaning_list VALUES(15250225243159, 15252558318715, 15252574608853, 'Ges; I; Av‡iv');
INSERT INTO tbl_meaning_list VALUES(15250225243159, 15252558358790, 15252574656706, 'c«vYx; Rxe; Rš‘; cï c«K…wZ †jvK ev gvbyl');
INSERT INTO tbl_meaning_list VALUES(15250225243159, 15252558442069, 15252574753142, 'Ab¨; Aci: Av‡iK Rb');
INSERT INTO tbl_meaning_list VALUES(15250225243159, 15252558515898, 15252574911717, 'DËi; Reve');

INSERT INTO tbl_meaning_list VALUES(15250225243159, 15252558645441, 15252575007469, '‡Kvb wKQy; †h †KD');
INSERT INTO tbl_meaning_list VALUES(15250225243159, 15252558686948, 15252575104041, '‡h †KD; †h †Kvb †jvK; †h †Kvb; †h‡Kn; †h †Kvb GKRb');
INSERT INTO tbl_meaning_list VALUES(15250225243159, 15252558754270, 15252575238338, '‡h †Kv‡bv wKQy; hvnv nh় wKQy; hvnv-wKQy; hvnv nh় wKQy; hvnv-wKQy; K”Qy');
INSERT INTO tbl_meaning_list VALUES(15250225243159, 15252558833740, 15252575324513, '`…wó †MvPi nIqv');
INSERT INTO tbl_meaning_list VALUES(15250225243159, 15252558893476, 15252575417466, 'c«‡qvM Kiv');

INSERT INTO tbl_meaning_list VALUES(15250225243159, 11222222, 1111111, 'aaaaaaaaaa');
-- practice
-- test
-- Word Champ
```
INSERT INTO tbl_word_list VALUES(88888888888, 'Approach', null, null, null);
INSERT INTO tbl_word_list VALUES(88888888888, 'Area', null, null, null);
INSERT INTO tbl_word_list VALUES(88888888888, 'Argue', null, null, null);
INSERT INTO tbl_word_list VALUES(88888888888, 'Arm', null, null, null);
INSERT INTO tbl_word_list VALUES(88888888888, 'Around', null, null, null);

INSERT INTO tbl_word_list VALUES(88888888888, 'Arrive', null, null, null);
INSERT INTO tbl_word_list VALUES(88888888888, 'Art', null, null, null);
INSERT INTO tbl_word_list VALUES(88888888888, 'Article', null, null, null);
INSERT INTO tbl_word_list VALUES(88888888888, 'Artist', null, null, null);
INSERT INTO tbl_word_list VALUES(88888888888, 'As', null, null, null);

INSERT INTO tbl_word_list VALUES(88888888888, 'aaaaaaaaaa', null, null, null);

INSERT INTO tbl_spelling_list VALUES(15250225243159, 11222222, 1111111, 'aaaaaaaaaa');

INSERT INTO tbl_meaning_list VALUES(15250225243159, 11222222, 1111111, 'aaaaaaaaaa');























