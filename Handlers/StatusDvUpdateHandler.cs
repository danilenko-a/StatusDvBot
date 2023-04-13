using StatusDvBot.Interfaces;
using StatusDvBot.Models;
using StatusDvBot.Telegram;

namespace StatusDvBot.BotAction
{
    internal class StatusDvUpdateHandler : IUpdateHandler
    {
        async Task IUpdateHandler.Handle(Update update, IAnswerService botSender)
        {
            Console.WriteLine($"Handle message: text/action: {update.message?.text ?? update.callback_query?.data}, user: {update.callback_query?.from?.username ?? update.message?.from?.username} {update.callback_query?.from?.first_name ?? update.message?.from?.first_name}");

            if (update.message?.text == "/start")
            {
                var s = SendPhoto<InlineKeyboardMarkup>.GetSendMain("\r\n*Главное меню:*", update, "https://i.ibb.co/Y2fg9Pt/u-ajax-2.png");
                s.reply_markup?.AddLine("Самосвалы", "dump_trucks");
                s.reply_markup?.AddLine("Спецтехника", "special_trucks");
                await botSender.SendMessage(s);
            }
            else if (update.callback_query?.data == "main_menu")
            {
                var s = EditMessageMedia.GetFromUpdate("\r\n*Главное меню:*", update, "https://i.ibb.co/Y2fg9Pt/u-ajax-2.png");
                s.reply_markup?.AddLine("Самосвалы", "dump_trucks");
                s.reply_markup?.AddLine("Спецтехника", "special_trucks");
                await botSender.SendMessage(s);
            }
            else if (update.callback_query?.data == "dump_trucks")
            {
                var s = EditMessageMedia.GetFromUpdate("\r\n*Самосвалы:*", update, "https://i.ibb.co/Y2fg9Pt/u-ajax-2.png");
                s.reply_markup?.AddLine("В наличие", "dump_trucks_available");
                s.reply_markup?.AddLine("Ожидается поступление", "dump_trucks_expected_to_arrive");
                s.reply_markup?.AddLine("« Назад", "main_menu");
                await botSender.SendMessage(s);
            }
            else if (update.callback_query?.data == "special_trucks")
            {
                var s = EditMessageMedia.GetFromUpdate("\r\n*Спецтехника:*\r\nРаздел в разработке", update, "https://i.ibb.co/Y2fg9Pt/u-ajax-2.png");
                s.reply_markup?.AddLine("« Назад", "main_menu");
                await botSender.SendMessage(s);
            }
            else if (update.callback_query?.data == "dump_trucks_available")
            {
                var s = EditMessageMedia.GetFromUpdate("\r\n*Самосвалы:* в наличие", update, "https://i.ibb.co/Y2fg9Pt/u-ajax-2.png");

                s.reply_markup?.AddLine("Shacman SX33186T366, 2023", "shacman_SX33186T366_2023_info");
                s.reply_markup?.AddLine("Shacman SX3258DR384, 2022", "shacman_SX3258DR384_2022_info");
                s.reply_markup?.AddLine("« Назад", "dump_trucks");

                await botSender.SendMessage(s);
            }
            else if (update.callback_query?.data == "dump_trucks_expected_to_arrive")
            {
                var s = EditMessageMedia.GetFromUpdate("\n\r*Самосвалы*: ожидается поступление", update, "https://i.ibb.co/Y2fg9Pt/u-ajax-2.png");

                s.reply_markup?.AddLine("Shacman X3000, 2023", "shacman_X3000_2023_info");
                s.reply_markup?.AddLine("« Назад", "dump_trucks");

                await botSender.SendMessage(s);
            }

            //Самосвалы
            else if (update.callback_query?.data == "shacman_SX33186T366_2023_info")
            {
                var s = EditMessageMedia.GetFromUpdate("", update, "https://50.img.avito.st/image/1/1.GZu5j7a5tXKPJnd3h9s52nAss3gNrL2wCCy3dgUmv3A.Nh2q7f4XU5DVlNoaQ7iLBfFE8Ao2AXph2mCjXkM4svY");
                if (s.media == null)
                {
                    s.media = new InputMedia();
                }
                s.media.caption = "Характеристики самосвала *Шахман* 8х4:\r\n*Цвет*: золото\r\n*Мощность двигателя*: 430 л.с.\r\n*Экологический класс*: ЕВРО 5\r\n*Кабина*: X3000\r\n*Двигатель*: WP12.430E50\r\n*КПП*: 12JSD180TA (механика)\r\n*Количество передач*: 12-вперед, 2-назад\r\n*Передняя ось*: 9.5T MAN, задний мост 16T MAN\r\n*Передаточные числа*: 5.262\r\n*Объем топливного бака*: 500 л (алюминиевый)\r\n*Бескамерные шины*: 315/80R22.5\r\n*Грузоподъемность*: 40 000 кг\r\n*Объем кузова*: 35 куб. м.\r\n*Макс. угол подъема*: 30 градусов";
                s.reply_markup?.AddLine("Прислать документацию", "send_specification");
                s.reply_markup?.AddLine("Прислать ПТС", "send_pts");
                s.reply_markup?.AddLine("« Назад", "dump_trucks_available");

                await botSender.SendMessage(s);
            }
            else if (update.callback_query?.data == "shacman_SX3258DR384_2022_info")
            {
                var s = EditMessageMedia.GetFromUpdate("", update, "https://10.img.avito.st/image/1/1.I-l_jra5jwBJJ00FNfoPqbctiQrLrYfCzi2NBMMnhQI.Kz0g3rMqre45TNoBX_OO_pQZfBEGxZpEo8Dnjx4vkZk");
                if (s.media == null)
                {
                    s.media = new InputMedia();
                }
                s.media.caption = "Краткие характеристики\r\n*Колёсная формула:* 6х4;\r\n*Объем кузова:* 19,3 куб. м.;\r\n*Толщина дна кузова:* 8 мм;\r\n*Толщина бортов кузова:* 6 мм;\r\n*Двигатель:* Weichai WP10.336E53 (Евро 5), дизельный с турбонаддувом;\r\n*Рабочий объём:* 9,726 л;\r\n*Количество цилиндров/расположение:* 6/рядное;\r\n*Максимальная мощность:* 247 кВт (336 л.с.) при 1900 об/мин;\r\n*Коробка передач:* 12JSD160TA+КОМ QH50, механическая, синхронизированная, 12-ти ступенчатая (вперед – 12, назад – 2), с ручным управлением;\r\n*Объём топливного бака (алюминиевый):* 500 л;\r\n*Габаритные размеры:* 8329×2490×3450 мм;\r\n*Шины:* 315/80R22,5;\r\n*Комплектация:*\r\n–устройство вызова экстренных оперативных служб ЭРА-ГЛОНАСС;\r\n–электростеклоподъемники;\r\n-зеркала заднего вида с электроподогревом;\r\n–кондиционер.";
                s.reply_markup?.AddLine("Прислать документацию", "send_specification");
                s.reply_markup?.AddLine("Прислать ПТС", "send_pts");
                s.reply_markup?.AddLine("« Назад", "dump_trucks_available");

                await botSender.SendMessage(s);
            }
            else if (update.callback_query?.data == "shacman_X3000_2023_info")
            {
                var s = EditMessageMedia.GetFromUpdate("", update, "https://20.img.avito.st/image/1/1.9XM_jra5WZoJJ5ufWZW_RfctX5CLrVFYji1bnoMnU5g.a8ZUuBVqXMZdeqfzs44XQWFyCMFsZXNA3nWHfOuwiy8");
                if (s.media == null)
                {
                    s.media = new InputMedia();
                }
                s.media.caption = "Характеристики самосвала Шахман X3000:*\r\n*Экологический класс:* ЕВРО 5\r\n*Двигатель:* Cummins 385 л.с.\r\n*Рабочий объем:* 10850 см3\r\n*КПП:* 12JSD180TA\r\n*КОМ:* QH50\r\n*Передняя ось:* 9T MAN, задний мост 16T MAN\r\n*Передаточные числа:* 5.262\r\n*Алюминиевый топливный бак:* 500 л\r\n*Бескамерные шины:* 315/80R22.5\r\n*Рулевое управление (пр-во КНР)\r\n*Грузоподъемность:* 35 000 кг\r\n*Объем кузова:* 35, 00 куб. м.\r\n*Кузов с передним расположением подъемника:* 7600×2300× (1500+500) мм\r\n*Толщина металла кузова:* дно 8 мм, бок 6 мм\r\n*Толщина стального листа днища / бок. стенки, мм:* 8 / 6\r\n*Минимальный дорожный просвет, мм:* 300\r\n*Минимальный радиус разворота, м:* ≤ 24\r\n*Размеры самосвала (Д х Ш х В), мм:* 10230 х 2500 х 3450";
                s.reply_markup?.AddLine("Прислать документацию", "send_specification");
                s.reply_markup?.AddLine("Прислать ПТС", "send_pts");
                s.reply_markup?.AddLine("« Назад", "dump_trucks_expected_to_arrive");

                await botSender.SendMessage(s);
            }
            else if (update.callback_query?.data == "send_specification")
            {
                var m1 = await SendMessage(update, "Подготавливается документ. Пожалуйста, подождите.", botSender);
                await Task.Delay(TimeSpan.FromSeconds(1.5));
                var m2 = await SendMessage(update, "Почти готово.", botSender);
                await Task.Delay(TimeSpan.FromSeconds(1.5));

                await SendFile(update, botSender, "Тестовая спецификация на самосвал.pdf", "Документация.pdf");

                await DeleteMessage(update, botSender, m1);
                await DeleteMessage(update, botSender, m2);
            }
            else if (update.callback_query?.data == "send_pts")
            {
                var m1 = await SendMessage(update, "Подготавливается документ. Пожалуйста, подождите.", botSender);
                await Task.Delay(TimeSpan.FromSeconds(1.5));
                await Task.Delay(TimeSpan.FromSeconds(1.5));
                var m2 = await SendMessage(update, "Почти готово.", botSender);

                await SendFile(update, botSender, "Тестовый ПТС транспортного средства.pdf", "ПТС.pdf");

                await DeleteMessage(update, botSender, m1);
                await DeleteMessage(update, botSender, m2);
            }
        }

        private async Task SendFile(Update update, IAnswerService botSender, string filePath, string filename)
        {
            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                await botSender.SendDocumentAsync(new FileStreamDocument(fileStream, filename, update.callback_query?.message?.chat?.id ?? -1));
            }
        }

        private async Task DeleteMessage(Update update, IAnswerService botSender, Result<long> messageId)
        {
            if (!messageId.HasValue)
            {
                return;
            }

            var d = new DeleteMessage()
            {
                chat_id = update?.callback_query?.message?.chat?.id ?? -1,
                message_id = messageId.Value,
            };

            await botSender.SendMessage(d);
        }

        private async Task<Result<long>> SendMessage(Update update, string text, IAnswerService botSender, long? chat_id = null)
        {
            var s = chat_id.HasValue 
                ? new SendMessage<InlineKeyboardMarkup>() { chat_id = chat_id.Value, text = text }
                : SendMessage<InlineKeyboardMarkup>.GetSendMessage(text, update);

            var result = await botSender.SendMessage(s);
            return result;
        }
    }
}
